package individualapplication.controller;

import individualapplication.models.Notification;
import lombok.AllArgsConstructor;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;


@Controller
//@RequestMapping("message")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class MessageController {

    @MessageMapping("message")
    @SendTo("/topic/public-messages")
    public Notification sendMessageToUser(@RequestBody  Notification message) {
        return message;
    }

}
