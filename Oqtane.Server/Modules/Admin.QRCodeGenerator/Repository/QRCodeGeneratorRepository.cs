using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Admin.QRCodeGenerator.Models;

namespace Admin.QRCodeGenerator.Repository
{
    public class QRCodeGeneratorRepository : IQRCodeGeneratorRepository, IService
    {
        private readonly QRCodeGeneratorContext _db;

        public QRCodeGeneratorRepository(QRCodeGeneratorContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.QRCodeGenerator> GetQRCodeGenerators(int ModuleId)
        {
            return _db.QRCodeGenerator.Where(item => item.ModuleId == ModuleId);
        }

        public Models.QRCodeGenerator GetQRCodeGenerator(int QRCodeGeneratorId)
        {
            return _db.QRCodeGenerator.Find(QRCodeGeneratorId);
        }

        public Models.QRCodeGenerator AddQRCodeGenerator(Models.QRCodeGenerator QRCodeGenerator)
        {
            _db.QRCodeGenerator.Add(QRCodeGenerator);
            _db.SaveChanges();
            return QRCodeGenerator;
        }

        public Models.QRCodeGenerator UpdateQRCodeGenerator(Models.QRCodeGenerator QRCodeGenerator)
        {
            _db.Entry(QRCodeGenerator).State = EntityState.Modified;
            _db.SaveChanges();
            return QRCodeGenerator;
        }

        public void DeleteQRCodeGenerator(int QRCodeGeneratorId)
        {
            Models.QRCodeGenerator QRCodeGenerator = _db.QRCodeGenerator.Find(QRCodeGeneratorId);
            _db.QRCodeGenerator.Remove(QRCodeGenerator);
            _db.SaveChanges();
        }
    }
}
