package individualapplication.controller;

import individualapplication.configuration.security.auth.AuthenticationRequestFilter;
import individualapplication.logiclayer.places.PlaceAdminImpl;
import individualapplication.logiclayer.user.UserAdminImpl;
import individualapplication.models.AccessToken;
import individualapplication.models.places.GetPlacesResponse;
import individualapplication.models.places.Place;
import individualapplication.models.user.GetUsersResponse;
import individualapplication.models.user.User;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.security.test.context.support.WithMockUser;
import org.springframework.test.context.junit.jupiter.SpringExtension;
import org.springframework.test.web.servlet.MockMvc;

import java.util.Arrays;
import java.util.List;

import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import static org.springframework.http.MediaType.APPLICATION_JSON_VALUE;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@WebMvcTest(PlaceController.class)
@ExtendWith(SpringExtension.class)
@AutoConfigureMockMvc(addFilters = false)
class PlaceControllerTest {

    @MockBean
    private AuthenticationRequestFilter authenticationRequestFilter;

    @Autowired
    private MockMvc mockMvc;

    @MockBean
    private PlaceAdminImpl placeAdmin;

    @Test
    void getPlaces_shouldReturn200ResponseWithUserArray() throws Exception{
        Place place = Place.builder().name("Amsterdam").id(0L).build();
        GetPlacesResponse response = GetPlacesResponse.builder().places(List.of(place)).build();

        when(placeAdmin.getPlaces()).thenReturn(response);


        mockMvc.perform(get("/place"))
                .andDo(print())
                .andExpect(status().isOk())
                .andExpect(header().string("Content-Type", APPLICATION_JSON_VALUE))
                .andExpect(content().json("""
{"places":[{"id":0,"name":"Amsterdam"}]}
                                                                        """));

        verify(placeAdmin).getPlaces();
    }
}
