using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.DataAccess.Abstract.DataManagement;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.DTO.UserDTO;
using PersonalWebsite.Entity.Poco;
using PersonalWebsite.Entity.Result;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Concrete
{
	public class UserManager : GenericManager<UserDTORequest, UserDTOResponse, User>, IUserService
	{
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UserManager(IMapper mapper, IUnitOfWork uow, IConfiguration configuration) : base(mapper, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<ApiResponse<LoginDTOResponse>> LoginAsync(LoginDTORequest Entity)
        {
            var result = new ApiResponse<LoginDTOResponse>();
            var data = await _uow.GetRepository<User>().GetAsync(x => x.Id == 1);
            var mappdata = _mapper.Map<LoginDTOResponse>(data);


            if (data.UserName == Entity.UserName && BCrypt.Net.BCrypt.Verify(Entity.Password, data.Password))
            {

                var secretKey = _configuration["JWT:Token"];
                var issuer = _configuration["JWT:Issuer"];
                var audiance = _configuration["JWT:Audiance"];


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = audiance,
                    Issuer = issuer,
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, $"{data.UserName}"),
                        new Claim(ClaimTypes.Sid, data.Id.ToString())
                    }),
                    Expires = DateTime.Now.AddDays(20), // Token süresi (örn: 20 dakika)
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                LoginDTOResponse loginGetDTO = new()
                {
                    UserName = mappdata.UserName,
                    Token = tokenHandler.WriteToken(token),
                };
                result.StatusCode = 200;
                result.Data = loginGetDTO;
                return result;
            }
            result.Success = false;
            return result;

        }

        public async Task<ApiResponse<UserDTOResponse>> UpdateUserAsync(UserDTORequest Entity)
        {
            var result = new ApiResponse<UserDTOResponse>();
            var data = _mapper.Map<User>(Entity);
            data.Password = BCrypt.Net.BCrypt.HashPassword(Entity.Password);
            await _uow.GetRepository<User>().UpdateAsync(data);
            result.Success = await _uow.SaveChangesAsync();
            return result;
        }
    }
}
