package individualapplication.datalayer.usermatch.usermatchalgochoice;

import org.springframework.data.jpa.repository.JpaRepository;

public interface UserAlgoChoiceRepository extends JpaRepository<UserAlgoChoiceEntity, Long> {
    UserAlgoChoiceEntity getUserAlgoChoiceEntityByUserId(Long id);
}
