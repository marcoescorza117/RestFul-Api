﻿using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Mappings
{//registrar tipos de conversiones //herendado profile de automapper
    public class AutomapperProfile :Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
