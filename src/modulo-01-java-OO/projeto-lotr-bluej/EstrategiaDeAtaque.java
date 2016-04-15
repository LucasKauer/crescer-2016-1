import java.util.ArrayList;

public interface EstrategiaDeAtaque {
    public ArrayList<Elfo> getOrdemDoUltimoAtaque();
    public void atacar(ArrayList<Elfo> pelotao, ArrayList<Dwarf> dwarves);
}