﻿using System;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core
{
    public class BinarySerializer : AbstractSerializer
    {
        private readonly IWindsorContainer container;

        public BinarySerializer(IWindsorContainer container)
        {
            this.container = container;
        }


        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(IBinarySerializer<TModel>);
            object instance = container.Resolve(serviceType);

            ISerializer<TModel> serializer = (IBinarySerializer<TModel>)instance;
            return serializer;

        }

        protected override object GetSerializer(Type modelType)
        {
            Type genericType = typeof(IBinarySerializer<>).MakeGenericType(modelType);
            object instance = container.Resolve(genericType);
            return instance;
        }
    }
}