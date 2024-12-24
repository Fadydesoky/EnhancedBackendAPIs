// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcApi {
  public static partial class UserService
  {
    static readonly string __ServiceName = "user.UserService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcApi.GetUserRequest> __Marshaller_user_GetUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcApi.GetUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcApi.UserReply> __Marshaller_user_UserReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcApi.UserReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcApi.UsersReply> __Marshaller_user_UsersReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcApi.UsersReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcApi.CreateUserRequest> __Marshaller_user_CreateUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcApi.CreateUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcApi.UpdateUserRequest> __Marshaller_user_UpdateUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcApi.UpdateUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcApi.DeleteUserRequest> __Marshaller_user_DeleteUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcApi.DeleteUserRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcApi.GetUserRequest, global::GrpcApi.UserReply> __Method_GetUser = new grpc::Method<global::GrpcApi.GetUserRequest, global::GrpcApi.UserReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUser",
        __Marshaller_user_GetUserRequest,
        __Marshaller_user_UserReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcApi.UsersReply> __Method_GetAllUsers = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcApi.UsersReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllUsers",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_user_UsersReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcApi.CreateUserRequest, global::GrpcApi.UserReply> __Method_CreateUser = new grpc::Method<global::GrpcApi.CreateUserRequest, global::GrpcApi.UserReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateUser",
        __Marshaller_user_CreateUserRequest,
        __Marshaller_user_UserReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcApi.UpdateUserRequest, global::GrpcApi.UserReply> __Method_UpdateUser = new grpc::Method<global::GrpcApi.UpdateUserRequest, global::GrpcApi.UserReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateUser",
        __Marshaller_user_UpdateUserRequest,
        __Marshaller_user_UserReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcApi.DeleteUserRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteUser = new grpc::Method<global::GrpcApi.DeleteUserRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteUser",
        __Marshaller_user_DeleteUserRequest,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcApi.UserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UserService</summary>
    [grpc::BindServiceMethod(typeof(UserService), "BindService")]
    public abstract partial class UserServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcApi.UserReply> GetUser(global::GrpcApi.GetUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcApi.UsersReply> GetAllUsers(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcApi.UserReply> CreateUser(global::GrpcApi.CreateUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcApi.UserReply> UpdateUser(global::GrpcApi.UpdateUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteUser(global::GrpcApi.DeleteUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UserServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetUser, serviceImpl.GetUser)
          .AddMethod(__Method_GetAllUsers, serviceImpl.GetAllUsers)
          .AddMethod(__Method_CreateUser, serviceImpl.CreateUser)
          .AddMethod(__Method_UpdateUser, serviceImpl.UpdateUser)
          .AddMethod(__Method_DeleteUser, serviceImpl.DeleteUser).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcApi.GetUserRequest, global::GrpcApi.UserReply>(serviceImpl.GetUser));
      serviceBinder.AddMethod(__Method_GetAllUsers, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcApi.UsersReply>(serviceImpl.GetAllUsers));
      serviceBinder.AddMethod(__Method_CreateUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcApi.CreateUserRequest, global::GrpcApi.UserReply>(serviceImpl.CreateUser));
      serviceBinder.AddMethod(__Method_UpdateUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcApi.UpdateUserRequest, global::GrpcApi.UserReply>(serviceImpl.UpdateUser));
      serviceBinder.AddMethod(__Method_DeleteUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcApi.DeleteUserRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteUser));
    }

  }
}
#endregion
