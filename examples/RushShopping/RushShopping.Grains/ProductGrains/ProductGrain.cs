﻿using System;
using Ray.Core;
using RushShopping.Grains.States;
using Orleans;
using Ray.EventBus.RabbitMQ;
using RushShopping.Repository.Entities;

namespace RushShopping.Grains.ProductGrains
{
    [Producer, Observable]
    public class ProductGrain : RushShoppingGrain<ProductGrain, Guid, ProductState, Product>
    {
        public ProductGrain()
        {
        }

        public override Guid GrainId => this.GetPrimaryKey();
    }
}