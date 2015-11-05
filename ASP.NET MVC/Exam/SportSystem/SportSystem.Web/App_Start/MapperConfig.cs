using AutoMapper;
using SportSystem.Models;
using SportSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Match, MatchViewModel>()
                .ForMember(vm => vm.HomeTeam, opt => opt.MapFrom(m => m.HomeTeam.Name))
                .ForMember(vm => vm.AwayTeam, opt => opt.MapFrom(m => m.AwayTeam.Name));

            Mapper.CreateMap<Team, TeamViewModel>()
                .ForMember(vm => vm.VotesCount, opt => opt.MapFrom(t => t.Votes.Count));

            Mapper.CreateMap<Team, DetailedTeamViewModel>();

            Mapper.CreateMap<Player, PlayerViewModel>();

            Mapper.CreateMap<Match, DetailedMatchViewModel>()
                .ForMember(vm => vm.Comments, opt => opt.MapFrom(t => t.Comments));

            Mapper.CreateMap<Comment, CommentViewModel>();
        }
    }
}