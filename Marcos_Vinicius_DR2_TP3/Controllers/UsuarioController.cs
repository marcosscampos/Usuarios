using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marcos_Vinicius_DR2_TP3.Models;

namespace Marcos_Vinicius_DR2_TP3.Controllers {
    public class UsuarioController : Controller {

        public ActionResult Index() {
            return View(BuscarUsuarios());
        }

        public ActionResult Details(int id) {
            return View(BuscaId(id));
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                Usuario usuario = new Usuario();
                usuario.UsuarioId = SearchId();
                usuario.Nome = collection["Nome"];
                usuario.Sobrenome = collection["Sobrenome"];
                usuario.DataDeAniversario = Convert.ToDateTime(collection["DataDeAniversario"]);

                AddId();
                AddUsuario(usuario);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        public ActionResult Edit(int id) {
            return View(BuscaId(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                Usuario usuario = new Usuario();
                usuario.UsuarioId = SearchId();
                usuario.Nome = collection["Nome"];
                usuario.Sobrenome = collection["Sobrenome"];
                usuario.DataDeAniversario = Convert.ToDateTime(collection["DataDeAniversario"]);

                EditarUsuario(id, usuario);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        public ActionResult Delete(int id) {
            return View(BuscaId(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                DeletarUsuario(id);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        public ActionResult Search()
        {
            string search = "";
            return View(BuscaUsuarios(search));
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            try
            {
                return View(BuscaUsuarios(search));
            }
            catch
            {
                return View();
            }
        }

        private static int _UsuarioId = 0;

        public static int AddId() {
            _UsuarioId = _UsuarioId + 1;
            return _UsuarioId;
        }

        public static int SearchId() {
            return AddId();
        }

        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario()
            {
                UsuarioId = 1, Nome = "Marcos", Sobrenome = "Vinicius",
                DataDeAniversario = Convert.ToDateTime("08/03/2019")
            },
            new Usuario()
            {
                UsuarioId = 2, Nome = "Lais", Sobrenome = "Miranda",
                DataDeAniversario = Convert.ToDateTime("01/09/2019")
            },
            new Usuario()
            {
                UsuarioId = 3, Nome = "Fabio", Sobrenome = "Martins",
                DataDeAniversario = Convert.ToDateTime("14/12/2019")
            },
            new Usuario()
            {
                UsuarioId = 4, Nome = "Matheus", Sobrenome = "Santos",
                DataDeAniversario = Convert.ToDateTime("01/05/2019")
            }
        };

        public static void AddUsuario(Usuario usuario) {
            usuarios.Add(usuario);
        }

        public static List<Usuario> BuscaUsuarios(string busca) {
            List<Usuario> result = new List<Usuario>();
            foreach (Usuario users in usuarios) {
                if (users.Nome.Contains(busca)) {
                    result.Add(users);
                }
            }

            return result;
        }

        public static Usuario BuscaId(int id) {
            Usuario result = new Usuario();
            foreach (Usuario users in usuarios) {
                if (users.UsuarioId == id) {
                    result.Nome = users.Nome;
                    result.Sobrenome = users.Sobrenome;
                    result.DataDeAniversario = users.DataDeAniversario;
                    break;
                }
            }

            return result;
        }

        public static List<Usuario> BuscarUsuarios() {
            return usuarios;
        }

        public static void EditarUsuario(int id, Usuario usuariosEdit) {
            foreach (Usuario users in usuarios) {
                if (users.UsuarioId == id) {
                    users.Nome = usuariosEdit.Nome;
                    users.Sobrenome = usuariosEdit.Sobrenome;
                    users.DataDeAniversario = usuariosEdit.DataDeAniversario;
                    break;
                }
            }
        }

        public static void DeletarUsuario(int id) {
            foreach (Usuario users in usuarios) {
                if (users.UsuarioId == id) {
                    usuarios.Remove(users);
                    break;
                }
            }
        }
    }
}
