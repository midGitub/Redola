﻿namespace Redola.Rpc.DynamicProxy.CastleIntegration
{
    public static class RpcActorExtensions
    {
        public static void Register<TService>(this RpcActor localActor, TService service)
        {
            var localService = RpcServiceGenerator.CreateService<TService>(localActor, service);
            localActor.RegisterRpcHandler(localService as RpcHandler);
        }

        public static TService Resolve<TService>(this RpcActor localActor, string service)
        {
            var remoteService = RpcServiceProxyGenerator.CreateServiceProxy<TService>(localActor, service);
            localActor.RegisterRpcHandler(remoteService as RpcHandler);
            return remoteService;
        }
    }
}
