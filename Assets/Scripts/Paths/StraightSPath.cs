using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightSPath : MonoBehaviour, IPath
{
    float xOffset; //position of center of the s
    float yOffset;
    float xLength; //positive length means start on the right, negative length flips it
    float yLength; // same thing
    float distance; /*distance between horizontal parts of the s*/
    float angle; //not working yet
    float xSpeed;
    float ySpeed; // tiles per second
    int time;

    int bendCount; //which stage in the motion is it in
    int verticalTrackTime; //in frames
    int horizontalTrackTime; // in frames
    int firstTrackTime;
    int bendNumber;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        bendCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        time++;
    }
    public void SetPathParams(List<float> pathParams) {
        xOffset = pathParams[0];
        yOffset = pathParams[1];
        xLength = pathParams[2];
        yLength = pathParams[3];
        distance = pathParams[4];
        angle = pathParams[5];
        xSpeed = pathParams[6];
        ySpeed = pathParams[7];
        bendNumber = (int) (Mathf.Floor(Mathf.Abs(yLength) / distance - 0.001f) + Mathf.Floor(Mathf.Abs(yLength) / distance + 0.001f));
        verticalTrackTime = (int) (distance / ySpeed * 60);
        horizontalTrackTime = (int) (Mathf.Abs(xLength) / xSpeed * 60);
        float xdist = 15 * xLength / Mathf.Abs(xLength) - (xOffset + xLength / 2) + xLength;
        firstTrackTime = (int) (Mathf.Abs(xdist) / xSpeed * 60 + 2);
        xSpeed = xSpeed / 60;
        ySpeed = ySpeed / 60;
        //float ydist = 15 * yLength / Mathf.Abs(yLength) - (yOffset + yLength / 2)
    }
    public void Move() {
        bendCount = (time - firstTrackTime + horizontalTrackTime) / (verticalTrackTime + horizontalTrackTime) * 2 + ((time - firstTrackTime + horizontalTrackTime) % (verticalTrackTime + horizontalTrackTime)) / horizontalTrackTime + 1;
        if (bendCount < 1) {bendCount = 1;}
        if (bendCount > bendNumber) {bendCount = bendNumber;}
        int timeSinceTurn = (time - firstTrackTime + horizontalTrackTime) % (verticalTrackTime + horizontalTrackTime) - (time - firstTrackTime + horizontalTrackTime) % (verticalTrackTime + horizontalTrackTime) / horizontalTrackTime * horizontalTrackTime;
        if (bendCount == 1) {
            float xpos = - xLength / 2 + xOffset + xLength / Mathf.Abs(xLength) * xSpeed * (firstTrackTime - time);
            float ypos = yLength / 2 + yOffset;
            transform.localPosition = new Vector3(xpos, ypos, 0);
        }
        else if (bendCount >= bendNumber) {
            if (bendNumber % 2 == 0) {
                transform.localPosition += new Vector3(0, -ySpeed * yLength / Mathf.Abs(yLength), 0);
            }
            else {
                transform.localPosition += new Vector3(- xLength / (- ((bendCount - 1) % 4) + 1) * xSpeed / Mathf.Abs(xLength), 0, 0);
            }
        }
        else if (bendCount % 2 == 0) {
            float xpos = (- (bendCount % 4) + 1) * xLength / 2 + xOffset;
            float ypos = yLength / 2 + yOffset + - (bendCount / 2 - 1) * distance * yLength / Mathf.Abs(yLength) - ySpeed * yLength / Mathf.Abs(yLength) * timeSinceTurn;
            transform.localPosition = new Vector3(xpos, ypos, 0);
        }
        else {
            float xpos = (- ((bendCount - 1) % 4) + 1) * xLength / 2 + xOffset - (- ((bendCount - 1) % 4) + 1) * xSpeed * xLength / Mathf.Abs(xLength) * timeSinceTurn;
            float ypos = yLength / 2 + yOffset + - (bendCount / 2) * distance * yLength / Mathf.Abs(yLength);
            transform.localPosition = new Vector3(xpos, ypos, 0);
        }
        if (Mathf.Abs(transform.position[0]) > 40 || Mathf.Abs(transform.position[1]) > 40) {
            Destroy(gameObject);
        }
    }
}
