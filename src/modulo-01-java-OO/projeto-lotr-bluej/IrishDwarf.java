// C#, C++ public class IrishDwarf : Dwarf 
public class IrishDwarf extends Dwarf {

    public IrishDwarf(String nome) {
        super(nome);
    }

    public IrishDwarf(String nome, DataTerceiraEra dataNascimento) {
        super(nome, dataNascimento);
    }

    public void tentarSorte() {
        double numero = getNumeroSorte();

        if (numero == -3333.0) {
            this.inventario.aumentarUnidadesProporcionalQuantidadePorItem();
        }
    }
}