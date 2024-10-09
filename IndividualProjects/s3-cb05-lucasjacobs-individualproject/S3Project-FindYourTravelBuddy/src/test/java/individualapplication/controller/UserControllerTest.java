package individualapplication.controller;

import individualapplication.configuration.security.auth.AuthenticationRequestFilter;
import individualapplication.logiclayer.user.UserAdminImpl;
import individualapplication.models.AccessToken;
import individualapplication.models.user.CreateUserRequest;
import individualapplication.models.user.CreateUserResponse;
import individualapplication.models.user.GetUsersResponse;
import individualapplication.models.user.User;
import individualapplication.models.user.gender.GenderEnum;
import org.junit.jupiter.api.Test;

import org.junit.jupiter.api.extension.ExtendWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.security.test.context.support.WithMockUser;
import org.springframework.test.context.junit.jupiter.SpringExtension;
import org.springframework.test.web.servlet.MockMvc;

import java.time.LocalDate;
import java.util.Arrays;
import java.util.List;

import static org.mockito.Mockito.*;
import static org.springframework.http.MediaType.APPLICATION_JSON_VALUE;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@WebMvcTest(UserController.class)
@ExtendWith(SpringExtension.class)
@AutoConfigureMockMvc(addFilters = false)
class UserControllerTest {
    @Autowired
    private MockMvc mockMvc;

    @MockBean
    private AuthenticationRequestFilter authenticationRequestFilter;


    @MockBean
    private AccessToken accessToken;

    @MockBean
    private UserAdminImpl userAdmin;

    @Test
    void getUsers_shouldReturn200ResponseWithUserArray() throws Exception{
        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").build();
        GetUsersResponse response = GetUsersResponse.builder().users(List.of(user1)).build();

        when(userAdmin.getUsers()).thenReturn(response);


        mockMvc.perform(get("/users"))
                .andDo(print())
                .andExpect(status().isOk())
                .andExpect(header().string("Content-Type", APPLICATION_JSON_VALUE))
                .andExpect(content().json("""
{"users":[{"userName":"Henkie","firstName":"Test","lastName":"Test"}]}
                                                                        """));

        verify(userAdmin).getUsers();
    }

    @Test
    void createUser_shouldCreateAndReturn201_WhenRequestValid() throws Exception{
        CreateUserRequest expectedUser = CreateUserRequest.builder().firstName("Lucas")
                .lastName("Jacobs")
                .userName("roan")
                .email("test@gmail.com")
                .gender(GenderEnum.MALE)
                .birthday(LocalDate.of(2000, 12, 12))
                .password("1234567")
                .build();
        when(userAdmin.createUser(expectedUser)).thenReturn(CreateUserResponse.builder().id(0L).build());

        mockMvc.perform(post("/users")
                .contentType(APPLICATION_JSON_VALUE)
                .content("""
                        {
                            "firstName": "Lucas",
                            "lastName": "Jacobs",
                            "userName": "roan",
                            "email": "test@gmail.com",
                            "gender": "MALE",
                            "birthday": "2000-12-12",
                            "password": "1234567"
                        }
                        """))
                .andDo(print())
                .andExpect(status().isCreated())
                .andExpect(header().string("Content-Type",
                        APPLICATION_JSON_VALUE))
                .andExpect(content().json("""
                                                        {"id": 0}
                                                     """));
        verify(userAdmin).createUser(expectedUser);
    }

}
