#include <iostream>
#include <vector>

using namespace std;

class IObserver{
public:
    virtual void update(string state) = 0;
};

class Thread{
private:
    int id;
    string state;
    int priority;
    string culture;
    vector<IObserver*> observerlist;
    
    void notify(){
        for(auto obs: observerlist){
            obs->update(this->state);
        }
    }
    
public:

    Thread() : state("Created") {};
    void start(){
        this->state = "Started";
        notify();
    }
    
    void thread_abort(){
        this->state = "Aborted";
        notify();
    }
    
    void sleep(int ms){
        this->state = "Sleep";
        notify();
    }
    
    void wait(){
        this->state = "Waiting";
        notify();
    }
    
    void suspend(){
        this->state = "Suspended";
        notify();
    }
    
    void subscribe(IObserver* subscriber){
        observerlist.push_back(subscriber);
    }
     
    void unsubscribe(IObserver* unsubscriber){
        observerlist.erase(unsubscriber);
    }
};

class Dashboard : public IObserver{
    void printState(string state){
        cout << this->state << "\n";
    }
    
    void update(string state) override{
        printState();
    }
};
