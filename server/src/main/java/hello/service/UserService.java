package hello.service;

import hello.model.User;
import hello.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

/**
 * Created by Lavini on 11/27/2016.
 */

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public void saveUser(String name, String password){
        User user = new User();
        user.setName(name);
        user.setPassword(password);
        user.setScore(0);
        userRepository.save(user);
    }

    public void saveUser(User user){
        userRepository.save(user);
    }

    public User findUserByName(String name){
        return userRepository.findByName(name);
    }

    public List<User> getTop(){
        List<User> list = userRepository.findAll();
        Collections.sort(list, new Comparator<User>() {
            @Override
            public int compare(User o1, User o2) {
                return o2.getScore() - o1.getScore();
            }
        });
        int size = list.size() > 9 ? 9 : list.size();
        return list.subList(0, size);
    }

    public void updateScore(String name, String score){
        User user = findUserByName(name);
        user.setScore(Integer.parseInt(score));
        saveUser(user);
    }
}
