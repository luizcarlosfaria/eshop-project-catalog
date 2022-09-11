﻿using eShopCloudNative.Architecture.Data.Repositories;
using eShopCloudNative.Catalog.Architecture.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopCloudNative.Catalog.Entities;
public class ProductQueryRepository : CatalogQueryRepository<Product>
{
    public ProductQueryRepository(ISession session) : base(session)
    {
    }

    public async Task<Product> GetProductAsync(int productId)
        => await this.QueryOver.Where(it => it.ProductId == productId).SingleOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        => await this.QueryOver.Where(p => 
            p.Categories != null 
            && 
            p.Categories.Any(c => c.CategoryId == categoryId)
        ).ListAsync();

}
