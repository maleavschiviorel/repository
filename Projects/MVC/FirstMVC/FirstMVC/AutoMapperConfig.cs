using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Reflection;

namespace FirstMVC
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => GetProfiles(cfg));
            // Mapper.AssertConfigurationIsValid();
           
        }
        private static void GetProfiles(AutoMapper.IMapperConfigurationExpression configuration)
        {
            SetProfilesFromBll(configuration);
            SetProfilesFromWeb(configuration);
        }

        private static void SetProfilesFromBll(AutoMapper.IMapperConfigurationExpression configuration)
        {
            var profiles =Assembly.GetAssembly(typeof(BLL.AutoMapDomainToDto.BLLOrderProfile)).GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Profile)));

            foreach (var profile in profiles)
            {
                var profileInstance = (Profile)Activator.CreateInstance(profile);
                configuration.AddProfile(profileInstance);
            }
        }

        private static void SetProfilesFromWeb(AutoMapper.IMapperConfigurationExpression configuration)
        {
            var profiles = Assembly.GetAssembly(typeof(AutoMapDtoToModel.ModelClientProfile)).GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Profile)));

            foreach (var profile in profiles)
            {
                var profileInstance = (Profile)Activator.CreateInstance(profile);
                configuration.AddProfile(profileInstance);
            }
        }
    }
}