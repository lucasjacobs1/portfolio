package individualapplication.datalayer.usermatch.buddymatchalgo;

import org.springframework.data.jpa.repository.JpaRepository;

public interface BuddyMatchAlgoRepository extends JpaRepository<BuddyMatchAlgoEntity, Long> {
    BuddyMatchAlgoEntity findByName(String name);
}
