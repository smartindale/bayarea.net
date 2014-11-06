using NServiceBus;
using NServiceBus.Installation.Environments;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Amazoom.Portal
{
    public class EndpointConfig
    {
        public IBus Init()
        {
            return Configure.With(AllAssemblies.Matching("AI.").And("Amazoom.").And("NServiceBus."))
                 .StructureMapBuilder()
                 .UseTransport<Msmq>()
                 .UseNHibernateSagaPersister()
                 .UseNHibernateSubscriptionPersister()
                 .UseNHibernateTimeoutPersister()
                 .FileShareDataBus(ConfigurationManager.AppSettings["FileShareDataBus"])
                 .PurgeOnStartup(System.Diagnostics.Debugger.IsAttached)
                 .DefiningDataBusPropertiesAs(pi => pi.Name.EndsWith("Attachment"))
                 .DefiningCommandsAs(pi => pi.Namespace != null && pi.Namespace.Contains(".Contracts.Commands"))
                 .DefiningEventsAs(pi => pi.Namespace != null && pi.Namespace.Contains(".Contracts.Events"))
                 .DefiningMessagesAs(pi => pi.Namespace != null && pi.Namespace.Contains(".Contracts.Messages"))
                 .DefiningEncryptedPropertiesAs(pi => pi.Name.Contains("Secret"))
                 .DefiningExpressMessagesAs(pi => pi.Name.EndsWith("Express"))
                 .DefiningTimeToBeReceivedAs(t => t.Name.EndsWith("Expires") ? TimeSpan.FromSeconds(45) : TimeSpan.MaxValue)
                 .RijndaelEncryptionService()
                 .UnicastBus()
                 .CreateBus()
                 .Start(()=> Configure.Instance.ForInstallationOn<Windows>().Install());
        }
    }
}