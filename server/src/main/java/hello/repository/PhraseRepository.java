package hello.repository;

import hello.model.Phrase;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Lavini on 11/27/2016.
 */

@Repository
public interface PhraseRepository extends JpaRepository<Phrase, Integer>, JpaSpecificationExecutor<Phrase> {

    public List<Phrase> findByDifficulty(Integer level);

}
