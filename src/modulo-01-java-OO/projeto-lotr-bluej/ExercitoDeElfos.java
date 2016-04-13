import java.util.*;

public class ExercitoDeElfos {
    private HashMap<String, Elfo> exercito = new HashMap<>();
    
    public void alistar(Elfo elfo) {
        boolean podeAlistar = elfo instanceof ElfoVerde || elfo instanceof ElfoNoturno;
        
        if (podeAlistar) {
            exercito.put(elfo.getNome(), elfo);
        }
    }
    
    public HashMap<String, Elfo> getExercito() {
        return this.exercito;
    }
}