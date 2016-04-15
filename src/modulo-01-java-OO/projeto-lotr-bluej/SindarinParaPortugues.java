import java.util.*;

public class SindarinParaPortugues implements TradutorSindarin {
    private HashMap<String, String> dicionario = new HashMap<String, String>()
        {
            {
                put("amar", "terra");
                put("naur", "fogo");
                put("gwaew", "vento");
                put("nen", "água");
                put("gûr", "coração");
            }
        };

    public String traduzir(String palavraEmSindarin) {
        return dicionario.get(palavraEmSindarin);
    }
}





