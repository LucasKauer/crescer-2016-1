import java.util.*;

public class ExercitoDeElfos {
    private HashMap<String, Elfo> exercito = new HashMap<>();
    private HashMap<Status, ArrayList<Elfo>> porStatus = new HashMap<>();

    public void alistar(Elfo elfo) {
        boolean podeAlistar = elfo instanceof ElfoVerde || elfo instanceof ElfoNoturno;

        if (podeAlistar) {
            exercito.put(elfo.getNome(), elfo);
        }
    }

    public HashMap<String, Elfo> getExercito() {
        return this.exercito;
    }

    public Elfo buscar(String nome) {
        return this.exercito.get(nome);
    }

    public void agruparPorStatus() {
        for (Map.Entry<String, Elfo> chaveValor : this.exercito.entrySet()) {
            Elfo elfo = chaveValor.getValue();
            ArrayList<Elfo> statusNoAgrupamento = porStatus.get(elfo.getStatus());
            boolean aindaNaoTenhoStatusNoAgrupamento = statusNoAgrupamento == null;

            if (aindaNaoTenhoStatusNoAgrupamento) {
                statusNoAgrupamento = new ArrayList<Elfo>(Arrays.asList(elfo));
                porStatus.put(elfo.getStatus(), statusNoAgrupamento);
            }

            statusNoAgrupamento.add(elfo);
        }
    }

    public ArrayList<Elfo> buscar(Status status) {
        return this.porStatus.get(status);
    }
}