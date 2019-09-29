using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_Automatizacao_bloqueio.Models;
using Microsoft.EntityFrameworkCore;

namespace TCC_Automatizacao_bloqueio.Services
{
    public class TicketRecordService
    {

        private readonly TCC_Automatizacao_bloqueioContext _context;

        public TicketRecordService(TCC_Automatizacao_bloqueioContext context)
        {
            _context = context;
        }

        public async Task<List<TicketRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.TicketRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x=> x.User).Include(x=> x.User.Department).OrderByDescending(x=>x.Date).ToListAsync();

        }

        public async Task<List<IGrouping<Department,TicketRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.TicketRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
                    
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x => x.User).Include(x => x.User.Department)
                .OrderByDescending(x => x.Date).GroupBy(x=>x.User.Department).ToListAsync();

        }



    }
}
