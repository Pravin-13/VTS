using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VTS_API.Dtos;
using VTS_API.Helpers;
using VTS_API.Interfaces;
using VTS_API.Models;

namespace VTS_API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<UserController> logger;
        public UserController(IUnitOfWork uow, IMapper mapper, ILogger<UserController> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserReqDto userData)
        {
            ResponseResultDto result = new();
            try
            {
                User user = mapper.Map<User>(userData);
                user.CreatedBy = "LoggnedUserName";
                if (ModelState.IsValid)
                {
                    if (await this.uow.UserRepository.IsUserAlreadyExists(user))
                    {
                        result.MessageType = MessageConstant.Warning;
                        result.Message = MessageConstant.UserAlreadyExists;
                    }
                    else
                    {
                        await this.uow.UserRepository.AddUser(user);

                        if (await this.uow.SaveAsync())
                        {
                            result.MessageType = MessageConstant.Success;
                            result.Message = MessageConstant.UserAdded;
                        }
                        else
                        {
                            result.MessageType = MessageConstant.Error;
                            result.Message = MessageConstant.FailedToAddUser;
                        }
                    }
                }
                else
                {
                    result.MessageType = MessageConstant.Error;
                    result.Message = MessageConstant.InvalidData;
                }
            }
            catch (Exception ex)
            {
                result.MessageType = MessageConstant.Error;
                result.Message = MessageConstant.FailedToAddUser;
                logger.Log(LogLevel.Error, ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserReqDto userData)
        {
            ResponseResultDto result = new();
            User user = await this.uow.UserRepository.FindUserByUserID(userData.UserID);
            try
            {
                mapper.Map(userData, user);
                user.ModifiedBy = "LoggnedUserName";
                user.ModifiedOn = DateTime.Now;

                if (ModelState.IsValid)
                {
                    if (await this.uow.UserRepository.IsUserAlreadyExists(user))
                    {
                        result.MessageType = MessageConstant.Warning;
                        result.Message = MessageConstant.UserAlreadyExists;
                    }
                    else
                    {
                        await this.uow.UserRepository.UpdateUser(user);

                        if (await this.uow.SaveAsync())
                        {
                            result.MessageType = MessageConstant.Success;
                            result.Message = MessageConstant.UserUpdated;
                        }
                        else
                        {
                            result.MessageType = MessageConstant.Error;
                            result.Message = MessageConstant.FailedToUpdateUser;
                        }
                    }
                }
                else
                {
                    result.MessageType = MessageConstant.Error;
                    result.Message = MessageConstant.InvalidData;
                }
            }
            catch (Exception ex)
            {
                result.MessageType = MessageConstant.Error;
                result.Message = MessageConstant.FailedToUpdateUser;
                logger.Log(LogLevel.Error, ex.Message);
            }

            return Ok(result);
        }
    }
}
