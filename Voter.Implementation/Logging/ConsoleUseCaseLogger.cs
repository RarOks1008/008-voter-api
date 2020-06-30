using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;

namespace Voter.Implementation.Logging
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationActor actor, object data)
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
            Console.WriteLine($"{DateTime.Now} - {actorIdentity} wants to execute {useCaseName} using this data: {JsonConvert.SerializeObject(data)}");
        }
    }
}
