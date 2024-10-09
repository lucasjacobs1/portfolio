package individualapplication.datalayer.userrepo;

import individualapplication.models.user.gender.GenderEnum;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface UserRepository extends JpaRepository<UserEntity, Long> {
    boolean existsByUserName(String userName);
    List<UserEntity> getUserEntitiesByGender(GenderEnum gender);
    UserEntity findByUserName(String username);

}