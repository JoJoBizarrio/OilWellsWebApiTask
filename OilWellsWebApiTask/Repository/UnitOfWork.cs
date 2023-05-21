using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;

namespace OilWellsWebApiTask.Repository
{
	public class UnitOfWork : IDisposable
	{
		private readonly DataContext _dataContext;

		private bool disposed = false;

		private Repository<DrillBlock> _drillBlocksRepository;
		private Repository<DrillBlockPoint> _drillBlockPointsRepository;
		private Repository<Hole> _holesRepository;
		private Repository<HolePoint> _holePointsRepository;

		public Repository<DrillBlock> DrillBlocksRepository
		{
			get
			{
				_drillBlocksRepository ??= new Repository<DrillBlock>(_dataContext);

				return _drillBlocksRepository;
			}
		}

		public Repository<DrillBlockPoint> DrillBlockPointsRepository
		{
			get
			{
				_drillBlockPointsRepository ??= new Repository<DrillBlockPoint>(_dataContext);

				return _drillBlockPointsRepository;
			}
		}

		public Repository<Hole> HolesRepository
		{
			get
			{
				_holesRepository ??= new Repository<Hole>(_dataContext);

				return _holesRepository;
			}
		}

		public Repository<HolePoint> HolePointsRepository
		{
			get
			{
				_holePointsRepository ??= new Repository<HolePoint>(_dataContext);

				return _holePointsRepository;
			}
		}

		public UnitOfWork(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_dataContext.Dispose();
				}

				disposed = true;
			}
		}
	}
}