
namespace Amazoom.Email.Endpoint
{
    using NServiceBus;
    using System;
    using System.Configuration;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher,IWantCustomInitialization
    {
        public void Init()
        {
            new Bootstrapper().BootstrapStructureMap();
            Configure.With(AllAssemblies.Matching("AI.").And("Amazoom.").And("NServiceBus."))
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
                 .RijndaelEncryptionService(); 
        }
    }
}
