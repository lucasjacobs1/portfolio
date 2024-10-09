package individualapplication.datalayer.placerepo;

import org.springframework.data.jpa.repository.JpaRepository;

public interface PlaceRepository extends JpaRepository<PlaceEntity, Long> {
    PlaceEntity findByName(String name);
}
