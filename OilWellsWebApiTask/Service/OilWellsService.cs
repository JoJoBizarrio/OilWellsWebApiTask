using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;

namespace OilWellsWebApiTask.Service
{
	public class OilWellsService : IOilWellsService // нужо ли разделить этот класс на несколько?
	{
		private readonly DataContext _dataContext;

		public OilWellsService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<DrillBlock>> GetAllDrillBlocksAsync()
		{
			return await _dataContext.DrillBlocks.ToListAsync();
		}

		public async Task<DrillBlock> GetSingeDrillBlockAsync(int id)
		{
			return await _dataContext.DrillBlocks.FindAsync(id);
		}

		public async Task<List<DrillBlock>> AddDrillBlockAsync(DrillBlock drillBlock)
		{
			drillBlock.LastUpdateDate = DateTime.UtcNow;
			await _dataContext.DrillBlocks.AddAsync(drillBlock);
			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlocks.ToListAsync();
		}

		public async Task<List<DrillBlock>> DeleteDrillBlockAsync(int id)
		{
			DrillBlock removedDrillBlock = await _dataContext.DrillBlocks.FindAsync(id);

			if (removedDrillBlock == null)
			{
				return null;
			}

			_dataContext.DrillBlocks.Remove(removedDrillBlock);

			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlocks.ToListAsync();
		}

		public async Task<List<DrillBlock>> UpdateDrillBlockAsync(int id, DrillBlock request)
		{
			DrillBlock updatedDrillBlock = await _dataContext.DrillBlocks.FindAsync(id);

			if (updatedDrillBlock == null)
			{
				return null;
			}

			updatedDrillBlock.Name = request.Name;
			updatedDrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlocks.ToListAsync();
		}

		public async Task<List<DrillBlockPoint>> GetAllDrillBlockPointsAsync()
		{
			return await _dataContext.DrillBlockPoints.ToListAsync();
		}

		public async Task<List<DrillBlockPoint>> GetDrillBlockPointsByDrillBlockAsync(int idDrillBlock)
		{
			DrillBlock drillBlock = await _dataContext.DrillBlocks.FindAsync(idDrillBlock);

			if (drillBlock == null)
			{
				return null;
			}

			return drillBlock.DrillBlockPoints;
		}

		public async Task<List<DrillBlockPoint>> AddDrillBlockPointAsync(DrillBlockPoint drillBlockPoints)
		{
			DrillBlock drillBlock = await _dataContext.DrillBlocks.FindAsync(drillBlockPoints.DrillBlockId);

			if (drillBlock == null || drillBlock.DrillBlockPoints.Any(dbp => dbp.Sequence == drillBlockPoints.Sequence))
			{
				return null;
			}

			drillBlock.DrillBlockPoints.Add(drillBlockPoints);
			drillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlockPoints.ToListAsync();
		}

		public async Task<List<DrillBlockPoint>> DeleteDrillBlockPointAsync(int id)
		{
			DrillBlockPoint removedDrillBlockPoints = await _dataContext.DrillBlockPoints.FindAsync(id);

			if (removedDrillBlockPoints == null)
			{
				return null;
			}

			_dataContext.DrillBlockPoints.Remove(removedDrillBlockPoints);
			removedDrillBlockPoints.DrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlockPoints.ToListAsync();
		}

		public async Task<List<DrillBlockPoint>> UpdateDrillBlockPointAsync(int id, DrillBlockPoint request)
		{
			DrillBlockPoint updatedDrillBlockPoints = await _dataContext.DrillBlockPoints.FindAsync(id);

			if (updatedDrillBlockPoints == null
				|| updatedDrillBlockPoints.DrillBlock.DrillBlockPoints.Any(dbp => dbp.Sequence == request.Sequence)) // где нужно проводить валидацию данных?
			{
				return null;
			}

			updatedDrillBlockPoints.X = request.X;
			updatedDrillBlockPoints.Y = request.Y;
			updatedDrillBlockPoints.Z = request.Z;
			updatedDrillBlockPoints.Sequence = request.Sequence;
			updatedDrillBlockPoints.DrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.DrillBlockPoints.ToListAsync();
		}

		public async Task<List<Hole>> GetAllHolesAsync()
		{
			return await _dataContext.Holes.ToListAsync();
		}

		public async Task<List<Hole>> GetHolesByDrillBlockAsync(int idDrillBlock)
		{
			DrillBlock drillBlock = await _dataContext.DrillBlocks.FindAsync(idDrillBlock);

			if (drillBlock == null)
			{
				return null;
			}

			return drillBlock.Holes;
		}

		public async Task<List<Hole>> AddHoleAsync(Hole hole)
		{
			DrillBlock drillBlock = await _dataContext.DrillBlocks.FindAsync(hole.DrillBlockId);

			if (drillBlock == null)
			{
				return null;
			}

			drillBlock.Holes.Add(hole);
			drillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.Holes.ToListAsync();
		}

		public async Task<List<Hole>> DeleteHoleAsync(int id)
		{
			Hole removedHole = await _dataContext.Holes.FindAsync(id);

			if (removedHole == null)
			{
				return null;
			}

			_dataContext.Holes.Remove(removedHole);
			removedHole.DrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.Holes.ToListAsync();
		}

		public async Task<List<Hole>> UpdateHoleAsync(int id, Hole request)
		{
			Hole updatedHole = await _dataContext.Holes.FindAsync(id);

			if (updatedHole == null)
			{
				return null;
			}

			updatedHole.Name = request.Name;
			updatedHole.Depth = request.Depth;
			updatedHole.DrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.Holes.ToListAsync();
		}

		public async Task<List<HolePoint>> GetAllHolePointsAsync()
		{
			return await _dataContext.HolePoints.ToListAsync();
		}

		public async Task<List<HolePoint>> AddHolePointAsync(HolePoint holePoint)
		{
			Hole hole = await _dataContext.Holes.FindAsync(holePoint.HoleId);

			if (hole == null)
			{
				return null;
			}

			hole.HolePoints.Add(holePoint);
			DrillBlock drillBlock = await _dataContext.DrillBlocks.FindAsync(hole.DrillBlockId);
			drillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.HolePoints.ToListAsync();
		}

		public async Task<List<HolePoint>> DeleteHolePointAsync(int id)
		{
			HolePoint removedHolePoint = await _dataContext.HolePoints.FindAsync(id);

			if (removedHolePoint == null)
			{
				return null;
			}

			_dataContext.HolePoints.Remove(removedHolePoint);
			removedHolePoint.Hole.DrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.HolePoints.ToListAsync();
		}

		public async Task<List<HolePoint>> UpdateHolePointAsync(int id, HolePoint request)
		{
			HolePoint updatedHolePoint = await _dataContext.HolePoints.FindAsync(id);

			if (updatedHolePoint == null)
			{
				return null;
			}

			updatedHolePoint.X = request.X;
			updatedHolePoint.Y = request.Y;
			updatedHolePoint.Z = request.Z;
			updatedHolePoint.Hole.DrillBlock.LastUpdateDate = DateTime.UtcNow;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.HolePoints.ToListAsync();
		}
	}
}