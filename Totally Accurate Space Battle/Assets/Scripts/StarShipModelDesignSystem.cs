using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {

    class StarShipModelDesignSystem : MonoBehaviour
    {
        //public GameObject StarShipComponent;
        //public GameObject StarShipGeometricShape;
        Camera playerCamera;


        // defining the main parts for the star ship
        public enum StarShipComponentTypes {
            Computer,
            Fuel_Tank,
            Laser,
            Fuel_Engine,
            Electric_Motor,
            Camera,
            Gun,
            Accumulator,
            Drill,
            Plasma_Torch,
            Solar_Panel
        }

        //defining the geometric shapes for the star ship
        public enum StarShipGeometricShapeTypes
        {
            Sphere,
            Cube,
            Cuboid,
            Cone,
            Cylinder
        }

        private bool buildModeOn_ = false;
        private bool canBuild_ = false;
        private float mY = 0f; // Mouse X.

        private StarShipBlockSystem blockSystem_;

        [SerializeField]
        private LayerMask buildableSurfacesLayer_;

        private Vector3 buildPos_;

        private GameObject currentTemplateBlock_;

        [SerializeField]
        private GameObject blockTemplatePrefab_;
        [SerializeField]
        private GameObject blockPrefab_;

        [SerializeField]
        private Material templateMaterial_;

        private int blockSelectCounter_ = 0;

        private void Start()
        {
            blockSystem_ = GetComponent<StarShipBlockSystem>();
        }

        private void LateUpdate() {
            playerCamera.transform.localEulerAngles = new Vector3(mY, 0f, 0f);
        }

        private void Update()
        {
            if (Input.GetKeyDown("z"))
            {
                buildModeOn_ = !buildModeOn_;

                if (buildModeOn_)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            }

            if (Input.GetKeyDown("x"))
            {
                blockSelectCounter_++;
                if (blockSelectCounter_ >= blockSystem_.allBlocks.Count) blockSelectCounter_ = 0;
            }

            if (buildModeOn_)
            {
                RaycastHit buildPosHit;
                playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
                if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 10, buildableSurfacesLayer_))
                {
                    Vector3 point = buildPosHit.point;
                    buildPos_ = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));
                    canBuild_ = true;
                }
                else
                {
                    Destroy(currentTemplateBlock_.gameObject);
                    canBuild_ = false;
                }
            }

            if (!buildModeOn_ && currentTemplateBlock_ != null)
            {
                Destroy(currentTemplateBlock_.gameObject);
                canBuild_ = false;
            }

            if (canBuild_ && currentTemplateBlock_ == null)
            {
                currentTemplateBlock_ = Instantiate(blockTemplatePrefab_, buildPos_, Quaternion.identity);
                currentTemplateBlock_.GetComponent<MeshRenderer>().material = templateMaterial_;
            }

            if (canBuild_ && currentTemplateBlock_ != null)
            {
                currentTemplateBlock_.transform.position = buildPos_;

                if (Input.GetMouseButtonDown(0))
                {
                    PlaceBlock();
                }
            }
        }

        private void PlaceBlock()
        {
            GameObject newBlock = Instantiate(blockPrefab_, buildPos_, Quaternion.identity);
            Block tempBlock = blockSystem_.allBlocks[blockSelectCounter_];
            newBlock.name = tempBlock.blockName + "-Block";
            newBlock.GetComponent<MeshRenderer>().material = tempBlock.blockMaterial;
        }
    
        /*public void AddGeometricShape( GameObject StarShipGeometricShape) {
            foreach (string s in Enum.GetNames(typeof(StarShipGeometricShapeTypes))) {
                StarShipGeometricShape = GameObject.Find(s);
                if (s == StarShipGeometricShape.ToString())
                {

                }
            }
        }*/
        
    }
}
