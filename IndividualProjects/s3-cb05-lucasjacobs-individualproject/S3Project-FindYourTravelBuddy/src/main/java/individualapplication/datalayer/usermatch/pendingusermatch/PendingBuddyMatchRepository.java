package individualapplication.datalayer.usermatch.pendingusermatch;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface PendingBuddyMatchRepository extends JpaRepository<PendingBuddyMatchEntity, Long> {
    List<PendingBuddyMatchEntity> getPendingBuddyMatchEntitiesByUserReceivedId(Long id);
}
