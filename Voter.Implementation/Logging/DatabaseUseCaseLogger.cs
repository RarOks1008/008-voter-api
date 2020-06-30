using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.EfDataAccess;

namespace Voter.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly VoterContext _context;

        public DatabaseUseCaseLogger(VoterContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            var actorIdentity = "Not Logged In";
            var useCaseName = "Login";
            if (actor != null)
            {
                actorIdentity = actor.Identity;
            }
            if (useCase != null)
            {
                useCaseName = useCase.Name;
            }
            _context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = actorIdentity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                Name = useCaseName
            });
            _context.SaveChanges();
        }
    }
}
