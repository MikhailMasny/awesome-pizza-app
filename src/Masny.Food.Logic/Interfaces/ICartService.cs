﻿using Masny.Food.Logic.Enums;
using Masny.Food.Logic.Models;
using System.Threading.Tasks;

namespace Masny.Food.Logic.Interfaces
{
    /// <summary>
    /// Cart service.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Get operation.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Cart data transfer object.</returns>
        Task<CartDto> GetAsync(string userId);

        /// <summary>
        /// Add or update operation.
        /// </summary>
        /// <param name="cartOperationType">Cart operation type.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="productDto">Product data transfer object.</param>
        Task AddOrUpdateAsync(CartOperationType cartOperationType, string userId, ProductDto productDto);

        /// <summary>
        /// Clear operation.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        Task ClearAsync(string userId);
    }
}