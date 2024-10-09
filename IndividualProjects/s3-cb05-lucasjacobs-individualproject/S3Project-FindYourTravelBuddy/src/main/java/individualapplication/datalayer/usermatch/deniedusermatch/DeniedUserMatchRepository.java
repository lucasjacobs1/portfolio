package individualapplication.datalayer.usermatch.deniedusermatch;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface DeniedUserMatchRepository extends JpaRepository<DeniedUserMatchEntity, Long> {
    List<DeniedUserMatchEntity> getDeniedUserMatchEntitiesByUserId(Long user);
}
