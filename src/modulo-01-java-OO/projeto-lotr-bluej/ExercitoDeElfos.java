import java.util.*;

public class ExercitoDeElfos {
    private HashMap<String, Elfo> exercito = new HashMap<>();
    private HashMap<Status, ArrayList<Elfo>> porStatus = new HashMap<>();
    // Estratégia inicial, método mudarEstrategia permite alterá-la após a criação do exército.
    private EstrategiaDeAtaque estrategia = new EstrategiaAntiNoturnos();

    public void alistar(Elfo elfo) throws NaoPodeAlistarException {
        boolean podeAlistar = elfo instanceof ElfoVerde || elfo instanceof ElfoNoturno;

        if (!podeAlistar) {
            throw new NaoPodeAlistarException();
        }
        
        exercito.put(elfo.getNome(), elfo);
    }

    public HashMap<String, Elfo> getExercito() {
        return this.exercito;
    }

    public Elfo buscar(String nome) {
        return this.exercito.get(nome);
    }

    public void agruparPorStatus() {
        porStatus.clear();
        for (Map.Entry<String, Elfo> chaveValor : this.exercito.entrySet()) {
            Elfo elfo = chaveValor.getValue();
            ArrayList<Elfo> statusNoAgrupamento = porStatus.get(elfo.getStatus());
            boolean aindaNaoTenhoStatusNoAgrupamento = statusNoAgrupamento == null;

            if (aindaNaoTenhoStatusNoAgrupamento) {
                statusNoAgrupamento = new ArrayList<Elfo>();
                porStatus.put(elfo.getStatus(), statusNoAgrupamento);
            }
            statusNoAgrupamento.add(elfo);
        }
    }

    public ArrayList<Elfo> buscar(Status status) {
        return this.porStatus.get(status);
    }

    public void atacar(ArrayList<Dwarf> alvos) {
        this.estrategia.atacar(
            new ArrayList<Elfo>(exercito.values()),
            alvos
        );
    }

    public ArrayList<Elfo> getOrdemDoUltimoAtaque() {
        return this.estrategia.getOrdemDoUltimoAtaque();
    }

    public void mudarEstrategia(EstrategiaDeAtaque estrategia) {
        this.estrategia = estrategia;
    }
}