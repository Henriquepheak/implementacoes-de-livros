﻿using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class AtendimentoItemDAL : DALBase<AtendimentoItem>
    {
        private Atendimento Atendimento { get; set; }

        public AtendimentoItemDAL(Atendimento atendimento, string dbPath) : base(dbPath)
        {
            this.Atendimento = atendimento;
        }

        public async override Task<List<AtendimentoItem>> GetAllAsync(Expression<Func<AtendimentoItem, object>> expression = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            expression = (expression == null) ? (i => i.Servico.Nome) : expression;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Descendente : orderByType;

            using (var context = DatabaseContext.GetContext(dbPath))
            {
                var query = PrepareDataToGetlAll(context, expression, orderByType);
                query = query.Include(i => i.Servico);
                query = query.Where(i => i.AtendimentoID == Atendimento.AtendimentoID);
                return await query.ToListAsync();
            }
        }
        public override Task<AtendimentoItem> UpdateAsync(AtendimentoItem item, long? itemID, params object[] associatedObjects)
        {
            return base.UpdateAsync(item, itemID, item.Atendimento, item.Servico);
        }
    }
}