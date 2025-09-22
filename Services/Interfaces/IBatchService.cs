using System;
using System.Collections.Generic;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.Services.Interfaces
{
    public interface IBatchService
    {
        // Near-expiry (kept)
        IEnumerable<Batch> GetNearExpiry(DateTime fromDate, int daysThreshold, int? medicineId = null);

        // Search/filter batches by medicine, expiry range, keyword (batchid/batchcode)
        IEnumerable<Batch> SearchBatches(int? medicineId, DateTime? fromExpiry, DateTime? toExpiry, string keyword);

        // Update allowed fields only
        void UpdateBatch(Batch batch);

        // Delete
        void DeleteBatch(int batchId);
    }
}
