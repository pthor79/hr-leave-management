﻿using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.MappingProfiles
{
    public class LeaveTypeProfile: Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDetailsDto, LeaveType>().ReverseMap();
        }
    }
}
