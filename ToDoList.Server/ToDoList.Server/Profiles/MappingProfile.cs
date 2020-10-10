using AutoMapper;
using Service.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Core.Identity;
using ToDoList.Server.Dtos;

namespace ToDoList.Server.Profiles
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            CreateMap<ToDo, CreateToDo>();
            CreateMap<CreateToDo, ToDo>();


            CreateMap<ReadToDo, ToDo>();
            CreateMap<ToDo, ReadToDo>();

            CreateMap<CreateConsumer, User>();
            CreateMap<User, CreateConsumer>();


        }


    }
}
