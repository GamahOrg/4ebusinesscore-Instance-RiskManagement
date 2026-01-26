using _4EPlatform.Application.Protos;
using Committees.API.Protos;
using ControlPanel.ORGHierararchy.Protos;
using ControlPanel.UserManagement.Protos;
using TicketingSystem.Application.Proto.Item;
namespace _4EPlatform_RiskManagement_API.Extention
{
    public static class GrpcClients
    {


        #region ControlPanel.Aggregator
        public static void AddCPAggregatorGrpcClients(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<OrgProtoService.OrgProtoServiceClient>(url);
            services.AddGrpcServiceClient<OrgMembersProtoService.OrgMembersProtoServiceClient>(url);

        }
        #endregion
        #region TicketingSystem
        public static void AddTicketingSystemGrpcClients(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<ItemProtoService.ItemProtoServiceClient>(url);

        }
        #endregion

        public static void AddUserManagementGrpcClient(
            this IServiceCollection services,
            string UserManagmentUrl)
        {
            services.AddGrpcServiceClient<UserProtoService.UserProtoServiceClient>(UserManagmentUrl);
            services.AddGrpcServiceClient<PermissionGroupingService.PermissionGroupingServiceClient>(UserManagmentUrl);
            services.AddGrpcServiceClient<DelegationUserProtoService.DelegationUserProtoServiceClient>(UserManagmentUrl);

        }

    }
}
