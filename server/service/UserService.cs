using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dto;
using server.Model;
using server.Views;

namespace server.service
{
    public class UserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> SearchUsers()
        {
            return await _context.Users
            .AsNoTracking()
            .ToListAsync();

        }

        public async Task<string> NewUser(UserDTO userDTO)
        {
            var id = BuscarQuatroDigito(userDTO.cpf);

            if (await VerificaUsuarioCadastro(id))
                return "Usuário já foi cadastrado";

            await _context.Users.AddAsync(new User
            {
                codigo = id,
                cpf = userDTO.cpf,
                nome = userDTO.nome,
                telefone = userDTO.telefone,
                endereco = userDTO.endereco,
            });

            await _context.SaveChangesAsync();

            return "Pessoa cadastrada com sucesso, código " + id;
        }

        private async Task<bool> VerificaUsuarioCadastro(int id)
        {
            var res = await _context.Users.Where(x => x.codigo == id).ToListAsync();

            if (res.Count > 0)
                return true;
            else
                return false;
        }

        private int BuscarQuatroDigito(string cpf)
        {
            string res = "";
            for (int i = 0; i < 4; i++)
            {
                res += cpf[i];
            }

            return Convert.ToInt32(res);
        }

        internal async Task<string> DeleteUser(int id)
        {
            var user = await _context.Users.Where(x => x.codigo == id).FirstOrDefaultAsync();

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
                return "Usuário já deletado";


            return "Deletado com sucesso";
        }

        internal async Task<string> PatchUser(User dto)
        {
            _context.Users.Update(dto);
            await _context.SaveChangesAsync();

            return "Atualizado com sucesso";
        }

        internal async Task<UserView> SearchUserById(int id)
        {
            var res = await _context.Users
                .Select(x => new UserView
                {
                    codigo = x.codigo,
                    cpf = x.cpf,
                    nome = x.nome,
                    telefone = x.telefone
                })
                .FirstOrDefaultAsync(x => x.codigo == id);

            return res;

        }
    }
}
