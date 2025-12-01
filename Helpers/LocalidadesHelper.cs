using System.Collections.Generic;
using System.Linq;

namespace Examen_BastianContreras_NicoleAlegria.Helpers
{
    public static class LocalidadesHelper
    {
        
        public static Dictionary<string, Dictionary<string, List<string>>> ObtenerChile()
        {
            return new Dictionary<string, Dictionary<string, List<string>>>
            {
                {
                    "Región de Arica y Parinacota", new Dictionary<string, List<string>> {
                        { "Arica", new List<string> { "Arica", "Camarones" } },
                        { "Parinacota", new List<string> { "Putre", "General Lagos" } }
                    }
                },
                {
                    "Región de Tarapacá", new Dictionary<string, List<string>> {
                        { "Iquique", new List<string> { "Iquique", "Alto Hospicio" } },
                        { "El Tamarugal", new List<string> { "Pozo Almonte", "Camiña", "Colchane", "Huara", "Pica" } }
                    }
                },
                {
                    "Región de Antofagasta", new Dictionary<string, List<string>> {
                        { "Antofagasta", new List<string> { "Antofagasta", "Mejillones", "Sierra Gorda", "Taltal" } },
                        { "El Loa", new List<string> { "Calama", "Ollagüe", "San Pedro de Atacama" } },
                        { "Tocopilla", new List<string> { "Tocopilla", "María Elena" } }
                    }
                },
                {
                    "Región de Atacama", new Dictionary<string, List<string>> {
                        { "Copiapó", new List<string> { "Copiapó", "Caldera", "Tierra Amarilla" } },
                        { "Chañaral", new List<string> { "Chañaral", "Diego de Almagro" } },
                        { "Huasco", new List<string> { "Vallenar", "Alto del Carmen", "Freirina", "Huasco" } }
                    }
                },
                {
                    "Región de Coquimbo", new Dictionary<string, List<string>> {
                        { "Elqui", new List<string> { "La Serena", "Coquimbo", "Andacollo", "La Higuera", "Paihuano", "Vicuña" } },
                        { "Choapa", new List<string> { "Illapel", "Canela", "Los Vilos", "Salamanca" } },
                        { "Limarí", new List<string> { "Ovalle", "Combarbalá", "Monte Patria", "Punitaqui", "Río Hurtado" } }
                    }
                },
                {
                    "Región de Valparaíso", new Dictionary<string, List<string>> {
                        { "Valparaíso", new List<string> { "Valparaíso", "Casablanca", "Concón", "Juan Fernández", "Puchuncaví", "Quintero", "Viña del Mar" } },
                        { "Isla de Pascua", new List<string> { "Isla de Pascua" } },
                        { "Los Andes", new List<string> { "Los Andes", "Calle Larga", "Rinconada", "San Esteban" } },
                        { "Petorca", new List<string> { "La Ligua", "Cabildo", "Papudo", "Petorca", "Zapallar" } },
                        { "Quillota", new List<string> { "Quillota", "Calera", "Hijuelas", "La Cruz", "Nogales" } },
                        { "San Antonio", new List<string> { "San Antonio", "Algarrobo", "Cartagena", "El Quisco", "El Tabo", "Santo Domingo" } },
                        { "San Felipe de Aconcagua", new List<string> { "San Felipe", "Catemu", "Llaillay", "Panquehue", "Putaendo", "Santa María" } },
                        { "Marga Marga", new List<string> { "Quilpué", "Limache", "Olmué", "Villa Alemana" } }
                    }
                },
                {
                    "Región Metropolitana", new Dictionary<string, List<string>> {
                        { "Santiago", new List<string> { "Santiago", "Cerrillos", "Cerro Navia", "Conchalí", "El Bosque", "Estación Central", "Huechuraba", "Independencia", "La Cisterna", "La Florida", "La Granja", "La Pintana", "La Reina", "Las Condes", "Lo Barnechea", "Lo Espejo", "Lo Prado", "Macul", "Maipú", "Ñuñoa", "Pedro Aguirre Cerda", "Peñalolén", "Providencia", "Pudahuel", "Quilicura", "Quinta Normal", "Recoleta", "Renca", "San Joaquín", "San Miguel", "San Ramón", "Vitacura" } },
                        { "Cordillera", new List<string> { "Puente Alto", "Pirque", "San José de Maipo" } },
                        { "Chacabuco", new List<string> { "Colina", "Lampa", "Til Til" } },
                        { "Maipo", new List<string> { "San Bernardo", "Buin", "Calera de Tango", "Paine" } },
                        { "Melipilla", new List<string> { "Melipilla", "Alhué", "Curacaví", "María Pinto", "San Pedro" } },
                        { "Talagante", new List<string> { "Talagante", "El Monte", "Isla de Maipo", "Padre Hurtado", "Peñaflor" } }
                    }
                },
                {
                    "Región del Libertador Gral. Bernardo O’Higgins", new Dictionary<string, List<string>> {
                        { "Cachapoal", new List<string> { "Rancagua", "Codegua", "Coinco", "Coltauco", "Doñihue", "Graneros", "Las Cabras", "Machalí", "Malloa", "Mostazal", "Olivar", "Peumo", "Pichidegua", "Quinta de Tilcoco", "Rengo", "Requínoa", "San Vicente" } },
                        { "Cardenal Caro", new List<string> { "Pichilemu", "La Estrella", "Litueche", "Marchihue", "Navidad", "Paredones" } },
                        { "Colchagua", new List<string> { "San Fernando", "Chépica", "Chimbarongo", "Lolol", "Nancagua", "Palmilla", "Peralillo", "Placilla", "Pumanque", "Santa Cruz" } }
                    }
                },
                {
                    "Región del Maule", new Dictionary<string, List<string>> {
                        { "Talca", new List<string> { "Talca", "Constitución", "Curepto", "Empedrado", "Maule", "Pelarco", "Pencahue", "Río Claro", "San Clemente", "San Rafael" } },
                        { "Cauquenes", new List<string> { "Cauquenes", "Chanco", "Pelluhue" } },
                        { "Curicó", new List<string> { "Curicó", "Hualañé", "Licantén", "Molina", "Rauco", "Romeral", "Sagrada Familia", "Teno", "Vichuquén" } },
                        { "Linares", new List<string> { "Linares", "Colbún", "Longaví", "Parral", "Retiro", "San Javier", "Villa Alegre", "Yerbas Buenas" } }
                    }
                },
                {
                    "Región de Ñuble", new Dictionary<string, List<string>> {
                        { "Diguillín", new List<string> { "Chillán", "Chillán Viejo", "Bulnes", "El Carmen", "Pemuco", "Pinto", "Quillón", "San Ignacio", "Yungay" } },
                        { "Itata", new List<string> { "Quirihue", "Cobquecura", "Coelemu", "Ninhue", "Portezuelo", "Ránquil", "Treguaco" } },
                        { "Punilla", new List<string> { "San Carlos", "Coihueco", "Ñiquén", "San Fabián", "San Nicolás" } }
                    }
                },
                {
                    "Región del Biobío", new Dictionary<string, List<string>> {
                        { "Concepción", new List<string> { "Concepción", "Coronel", "Chiguayante", "Florida", "Hualpén", "Hualqui", "Lota", "Penco", "San Pedro de la Paz", "Santa Juana", "Talcahuano", "Tomé" } },
                        { "Arauco", new List<string> { "Lebu", "Arauco", "Cañete", "Contulmo", "Curanilahue", "Los Álamos", "Tirúa" } },
                        { "Biobío", new List<string> { "Los Ángeles", "Antuco", "Cabrero", "Laja", "Mulchén", "Nacimiento", "Negrete", "Quilleco", "San Rosendo", "Santa Bárbara", "Tucapel", "Yumbel", "Alto Biobío" } }
                    }
                },
                {
                    "Región de La Araucanía", new Dictionary<string, List<string>> {
                        { "Cautín", new List<string> { "Temuco", "Carahue", "Cunco", "Curarrehue", "Freire", "Galvarino", "Gorbea", "Lautaro", "Loncoche", "Melipeuco", "Nueva Imperial", "Padre Las Casas", "Perquenco", "Pitrufquén", "Pucón", "Saavedra", "Teodoro Schmidt", "Toltén", "Vilcún", "Villarrica", "Cholchol" } },
                        { "Malleco", new List<string> { "Angol", "Collipulli", "Curacautín", "Ercilla", "Lonquimay", "Los Sauces", "Lumaco", "Purén", "Renaico", "Traiguén", "Victoria" } }
                    }
                },
                {
                    "Región de Los Ríos", new Dictionary<string, List<string>> {
                        { "Valdivia", new List<string> { "Valdivia", "Corral", "Lanco", "Los Lagos", "Máfil", "Mariquina", "Paillaco", "Panguipulli" } },
                        { "Ranco", new List<string> { "La Unión", "Futrono", "Lago Ranco", "Río Bueno" } }
                    }
                },
                {
                    "Región de Los Lagos", new Dictionary<string, List<string>> {
                        { "Llanquihue", new List<string> { "Puerto Montt", "Calbuco", "Cochamó", "Fresia", "Frutillar", "Llanquihue", "Los Muermos", "Maullín", "Puerto Varas" } },
                        { "Chiloé", new List<string> { "Castro", "Ancud", "Chonchi", "Curaco de Vélez", "Dalcahue", "Puqueldón", "Queilén", "Quellón", "Quemchi", "Quinchao" } },
                        { "Osorno", new List<string> { "Osorno", "Puerto Octay", "Purranque", "Puyehue", "Río Negro", "San Juan de la Costa", "San Pablo" } },
                        { "Palena", new List<string> { "Chaitén", "Futaleufú", "Hualaihué", "Palena" } }
                    }
                },
                {
                    "Región de Aysén", new Dictionary<string, List<string>> {
                        { "Coyhaique", new List<string> { "Coyhaique", "Lago Verde" } },
                        { "Aysén", new List<string> { "Aysén", "Cisnes", "Guaitecas" } },
                        { "Capitán Prat", new List<string> { "Cochrane", "O'Higgins", "Tortel" } },
                        { "General Carrera", new List<string> { "Chile Chico", "Río Ibáñez" } }
                    }
                },
                {
                    "Región de Magallanes", new Dictionary<string, List<string>> {
                        { "Magallanes", new List<string> { "Punta Arenas", "Laguna Blanca", "Río Verde", "San Gregorio" } },
                        { "Antártica Chilena", new List<string> { "Cabo de Hornos (Ex Navarino)", "Antártica" } },
                        { "Tierra del Fuego", new List<string> { "Porvenir", "Primavera", "Timaukel" } },
                        { "Última Esperanza", new List<string> { "Natales", "Torres del Paine" } }
                    }
                }
            };
        }

        // una lista manual en el orden geográfico exacto (Norte a Sur).
        public static List<string> GetRegiones()
        {
            return new List<string>
            {
                "Región de Arica y Parinacota",
                "Región de Tarapacá",
                "Región de Antofagasta",
                "Región de Atacama",
                "Región de Coquimbo",
                "Región de Valparaíso",
                "Región Metropolitana",
                "Región del Libertador Gral. Bernardo O’Higgins",
                "Región del Maule",
                "Región de Ñuble",
                "Región del Biobío",
                "Región de La Araucanía",
                "Región de Los Ríos",
                "Región de Los Lagos",
                "Región de Aysén",
                "Región de Magallanes"
            };
        }

        // Las Provincias y Comunas SÍ las ordenamos alfabéticamente para facilitar la búsqueda
        public static List<string> GetProvincias(string region)
        {
            var data = ObtenerChile();
            if (data.ContainsKey(region))
                return data[region].Keys.OrderBy(x => x).ToList();
            return new List<string>();
        }

        public static List<string> GetComunas(string region, string provincia)
        {
            var data = ObtenerChile();
            if (data.ContainsKey(region) && data[region].ContainsKey(provincia))
                return data[region][provincia].OrderBy(x => x).ToList();
            return new List<string>();
        }
    }
}