package individualapplication.datalayer.usermatch.matches;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface MatchRepository extends JpaRepository<MatchEntity, Long> {
    List<MatchEntity> getAllByBuddy1_IdOrBuddy2_Id(Long buddy1, Long buddy2);
}
