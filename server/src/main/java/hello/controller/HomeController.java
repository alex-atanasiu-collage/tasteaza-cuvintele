package hello.controller;

import java.util.List;

import hello.messages.LoginRequest;
import hello.messages.Message;
import hello.messages.PhraseRequest;
import hello.messages.ScoreRequest;
import hello.model.User;
import hello.service.PhraseService;
import hello.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class HomeController {

    @Autowired
    private UserService userService;

    @Autowired
    private PhraseService phraseService;

    @RequestMapping("/login")
    public Message login(@RequestBody LoginRequest request) {
        Message response = new Message();
        int existentUser;

        //check in the DB
        User user = userService.findUserByName(request.getName());
        if(user == null) {
            //new user
            userService.saveUser(request.getName(), request.getPassword());
            existentUser = 1;
        } else {
            if(!user.getPassword().equals(request.getPassword())) {
                //wrong password
                existentUser = 0;
            } else {
                //existing user
                existentUser = 1;
            }
        }

        if(existentUser == 1){
            response.setContent("yes [successful login]");
        } else {
            response.setContent("no [wrong password for existing user]");
        }

        return response;
    }

    @RequestMapping(value = "/getPhrase", method = RequestMethod.POST)
    public List<String> getWords(@RequestBody PhraseRequest request) {
        int level = Integer.parseInt(request.getLevel());
        int type = Integer.parseInt(request.getType());
        return phraseService.findPhrases(type, level, 25);
    }

    @RequestMapping(value = "/getTop", method = RequestMethod.GET)
    public List<User> getTop() {
        return userService.getTop();
    }

    @RequestMapping(value = "/saveScore", method = RequestMethod.POST)
    public void saveScore(@RequestBody ScoreRequest request){
        userService.updateScore(request.getName(), request.getScore());
    }

    @RequestMapping(value = "/test")
    public String test(){
        return "test";
    }

}
