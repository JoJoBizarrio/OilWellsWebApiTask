using OilWellsWebApiTask.Data;
using OilWellsWebApiTask.Models;
using OilWellsWebApiTask.Repository;

namespace OilWellsWebApiTask.Repositories
{
	public class UnitOfWork : IDisposable
	{
		private readonly DataContext _dataContext;

		private IRepository<DrillBlock> _drillBlocksRepository;
		private IRepository<DrillBlockPoint> _drillBlockPointsRepository;
		private IRepository<Hole> _holesRepository;
		private IRepository<HolePoint> _holePointsRepository;

		private bool disposed = false;

		public UnitOfWork(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public IRepository<DrillBlock> DrillBlocks
		{
			get
			{
				_drillBlocksRepository ??= new Repository<DrillBlock>(_dataContext);
				
				return _drillBlocksRepository;
			}
		}

		public IRepository<DrillBlockPoint> DrillBlockPoints
		{
			get
			{
				_drillBlockPointsRepository ??= new Repository<DrillBlockPoint>(_dataContext);

				return _drillBlockPointsRepository;
			}
		}

		public IRepository<Hole> Holes
		{
			get
			{
				_holesRepository ??= new Repository<Hole>(_dataContext);

				return _holesRepository;
			}
		}

		public IRepository<HolePoint> HolePoints
		{
			get
			{
				_holePointsRepository ??= new Repository<HolePoint>(_dataContext);

				return _holePointsRepository;
			}
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dataContext.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}