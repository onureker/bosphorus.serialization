﻿using System;
using Bosphorus.Container.Castle.Extra;

namespace Bosphorus.Serialization.Core
{
    public class XmlSerializer : AbstractSerializer
    {
        private readonly IServiceRegistry serviceRegistry;

        public XmlSerializer(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(IXmlSerializer<TModel>);
            object instance = serviceRegistry.Get(serviceType);

            ISerializer<TModel> serializer = (IXmlSerializer<TModel>)instance;
            return serializer;

        }

        protected override object GetSerializer(Type modelType)
        {
            Type genericType = typeof(IXmlSerializer<>).MakeGenericType(modelType);
            object instance  = serviceRegistry.Get(genericType);
            return instance;
        }
    }
}