package individualapplication.datalayer.usermatch.potential;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface PotentialUserMatchRepository extends JpaRepository<PotentialUserMatchEntity, Long> {
    List<PotentialUserMatchEntity> getPotentialUserMatchEntitiesByUserReceivedId(Long id);
    void deleteAllByUserReceivedId(Long id);
}
