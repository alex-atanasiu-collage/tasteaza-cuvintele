package hello.service;

import hello.model.Phrase;
import hello.repository.PhraseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.*;

/**
 * Created by Lavini on 11/27/2016.
 */

@Service
public class PhraseService {

    @Autowired
    private PhraseRepository phraseRepository;

    public List<String> findPhrases(Integer type, Integer difficulty, int number){
        List<Phrase> existingPhrases;
        List<Phrase> goodPhrases = new ArrayList<>();
        List<String> result = new ArrayList<>(number);
        Random rand = new Random();

        existingPhrases = phraseRepository.findByDifficulty(difficulty);
        for(Phrase p : existingPhrases) {
            if(p.getType() == type){
                goodPhrases.add(p);
            }
        }
        int n = goodPhrases.size();

        for(int i = 0; i < number; i++) {
            result.add(goodPhrases.get(rand.nextInt(n)).getText());
        }

        return result;
    }

}
