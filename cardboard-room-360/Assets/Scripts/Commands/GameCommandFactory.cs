using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
using ViewModel;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Scriptable/Game Command Factory")]
public class GameCommandFactory : ScriptableObject
{
    public CmdTurnRoom PerfomRoom(RoomData roomData, Room room)
    {
        return new CmdTurnRoom(roomData, room);
    }
}
