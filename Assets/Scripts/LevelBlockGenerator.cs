using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockGenerator : MonoBehaviour
{
    public LevelBlock levelBlock; //Bloque del nivel que hay que generar aleatoriamente
    public LevelBlock lastLevelBlock; // ultimo bloque colocado
    public LevelBlock currentLevelblock;
    public PipeMovement blockPipe;
    public float blockGeneratorTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        AddNewBlock();
        InvokeRepeating("GenerateNewBlockPipe", 0, blockGeneratorTime);
    }

    // Update is called once per frame
    void Update()
    {
        float xcam = Camera.main.transform.position.x;
        float xold = lastLevelBlock.exitPoint.position.x;
        if(xcam > xold + lastLevelBlock.width/2){
            RemoveOldBlock();
        }
    }

    public void AddNewBlock(){
        LevelBlock block = (LevelBlock) Instantiate(levelBlock);
        block.transform.SetParent(this.transform, false);

        Vector3 blockPosition = Vector3.zero;
        blockPosition = new Vector3(lastLevelBlock.exitPoint.position.x + block.width/2, lastLevelBlock.exitPoint.position.y, lastLevelBlock.exitPoint.position.z);
        block.transform.position = blockPosition;
        currentLevelblock = block;
    }

    public void RemoveOldBlock(){
        lastLevelBlock.transform.position = new Vector3(lastLevelBlock.transform.position.x + 2*lastLevelBlock.width, lastLevelBlock.transform.position.y, lastLevelBlock.transform.position.z);
        LevelBlock temp = lastLevelBlock;
        lastLevelBlock = currentLevelblock;
        currentLevelblock = temp;
        //AddNewBlock();
    }

    public void GenerateNewBlockPipe(){
        float distanceToGenerate = levelBlock.width/1.5f;
        float randomY = Random.Range(-2, 8);
        float randomV = Random.Range(2, 5);
        int randomM = Random.Range(-1, 1);
        PipeMovement pipeBlock = (PipeMovement)Instantiate(blockPipe);
        Vector3 pipePosition = Vector3.zero;
        pipePosition = new Vector3(Camera.main.transform.position.x + distanceToGenerate, randomY, 0);
        pipeBlock.speed = randomV;
        pipeBlock.directionPipe = randomM;
        pipeBlock.transform.position = pipePosition;
    }
}
