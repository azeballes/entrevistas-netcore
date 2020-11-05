namespace WebApi1.Models {
    public class Cliente {
        public int Identificador {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}

        public override bool Equals(object obj){
            if ( obj == null || !obj.GetType().Equals(typeof(Cliente)) )
                return false;
            var cliente = (Cliente) obj;
            return this.Identificador == cliente.Identificador
                && this.Apellido.Equals(cliente.Apellido)
                && this.Nombre.Equals(cliente.Nombre);
        }

        public override int GetHashCode() =>
            this.Identificador.GetHashCode() + this.Apellido.GetHashCode() + this.Nombre.GetHashCode();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}